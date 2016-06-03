def count_words(array)
  frequency = Hash.new(0)
  array.each { |word| frequency[word] += 1 }
  return frequency
end

file_contents = File.read('./wordcount.txt').gsub!(/[^0-9A-Za-z ]/, '').downcase.split(' ')
puts count_words(file_contents).sort_by {|_key, value| value}.reverse.to_h